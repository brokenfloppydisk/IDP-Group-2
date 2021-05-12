import random

def alphabet(capitalized = True):
    """Returns word list of the alphabet.

    Args:
        capitalized (bool): Whether the alphabet is capitalized
    
    Returns:
        string: The alphabet string
    """
    return [chr(i) for i in (range(65,91) if capitalized else range(97,123))]

def str_to_num(string):
    """Converts word string to word list of numbers from 1-26. (Can be used to convert a paragraph into a one-time-pad key)
    
    Args:
        string (string): The string to be converted
    
    Returns:
        string: The converted string
    """
    output = []
    string = format_string(string)
    for i in string:
        if i in alphabet():
            output.append(alphabet().index(i)+1)
    return output

def one_time_pad(string,key,encode = True, Caesar = False):
    """Encodes or decodes word one-time-pad.
    
    Args:
        string (string): The string to be encoded/decoded
        key (list or string): The key to be shifted by
        encode (bool): Sets encoding or decoding
        Caesar (bool): Sets Caesar Cipher mode
    
    Returns:
        string: The encoded/decoded string
    """
    output = ""
    string = format_string(remove_punc(string))
    keys = []
    if type(key) == list:
        keys = key
    elif type(key) == string:
        key = format_string(remove_punc(key),False)
        for i in key:
            keys.append(alphabet.index(key[i]))
    elif type(key) == int:
        keys = [key]
    for i in range(len(string)):
        if string[i] in alphabet():
            output += chr((alphabet().index(string[i])+(1 if encode == True else -1)*(keys[i] if Caesar==False else keys[0]))%26+65)
        else:
            output += " "
    return output

def book_cipher(book,string):
    """Returns a random key for a book cipher.
    
    Args:
        book (string): The book that the string is hidden in
        string (string): The string that is being hidden
    
    Returns:
        list: A list of lists where the first index is the word, and the second index is the character.
    """
    for i in string:
        if i not in book:
            print("Invalid key")
            return None
    string = list(format_string(remove_punc(string),True))
    words = words_list(book)
    letters_list = create_letters_list(words)
    output = []
    for i in range(len(string)):
        if string[i] == " ":
            output.append(" ")
        else:
            possible_pairs = letters_list[alphabet().index(list(string)[i])]
            if len(possible_pairs) == 1:
                output.append(possible_pairs[0])
            else:
                output.append(possible_pairs[random.randint(0,len(possible_pairs)-1)])
    return output

def decode_book(book,key):
    """Returns the message from word book cipher.
    
    Args:
        book (string): The book that the string is hidden in
        key (list): The key being used to decode the book cipher
    
    Returns:
        string: the decoded message
    """
    words = words_list(book)
    
    output = ""
    for i in range(len(key)):
        if key[i] == " ":
            output += " "
        else:
            
            output += list(words[key[i][0]-1])[key[i][1]-1]

    return output

def words_list(book):
    """Formats a string into a list of words.
    
    Args:
        book (string): The string to be formatted
    
    Returns:
        list: The list of words
    """

    book = list(format_string(remove_punc(book)))
    words = []
    word = ""
    for i in book:
        if i != " ":
            word += i
        else:
            words.append(word)
            word = ""
    words.append(word)
    return words

def create_letters_list(words):
    """Formats a words list into a letters list.
    
    Args:
        words (list): The words list to be formatted
    
    Returns:
        list: The letters list
    """
    letters_list = []
    for i in range(26):
        letters_list.append([])
    for i in range(len(words)):
        for j in range(len(words[i])):
            letters_list[alphabet().index(list(words[i])[j])].append([i+1,j+1])
    return letters_list
def format_string(string, keep_spaces = True):
    """Returns the string capitalized and with special characters removed.
    
    Args:
        string (string): The string to be formatted
        keep_spaces (bool): Whether or not to replace special characters with spaces.
    
    Returns:
        string: word formatted string
    """
    temp = ""
    for i in string:
        if i.upper() in alphabet():
            temp += i.upper()
        elif keep_spaces == True:
            temp += " "
    return temp

def remove_punc(string):
    """Removes punctuation and special characters from word string.
    
    Args:
        string (string): The string to be formatted
    
    Returns:
        string: word formatted string
    """
    temp = ""
    for i in string:
        if i.upper() in alphabet() or i == " ":
            temp += i
    return temp
    
