import ciphers

def check_input(message):
    user_input = str(input(message)).upper()
    if user_input.startswith("Y"):
        return True
    elif user_input.startswith("N"):
        return False
    else:
        print("Invalid input. Please try again.")
        return check_input(message) 



convert_key = check_input("Are you using a string as the key? ")

key = None

if convert_key == True:
    key = ciphers.str_to_num(input("Key:"))
else:
    complete = False
    key = []
    while complete!=True:
        user_input = input("Next key value (Type end to stop): ").upper()
        ints = [int(i) for i in list(user_input) if i.isdigit()]
        integers = ""
        for i in ints:
            integers += str(i)
        if ints != []:
            key.append(int(integers))
        elif "END" in user_input and len(key) > 1:
            complete=True
        else:
            print("Invalid input. Please try again.")
book = open("book.txt","r")
key = book.read()
key = str(ciphers.format_string(ciphers.remove_punc(key)))

caesar = check_input("Are you using a caesar cipher? ")

encode = check_input("Are you encoding a cipher? ")

secret_message = input("Input encoded cipher or cipher to decode: ")

output = ciphers.one_time_pad(secret_message, key, encode, caesar)

print("Output: " + str(output))




