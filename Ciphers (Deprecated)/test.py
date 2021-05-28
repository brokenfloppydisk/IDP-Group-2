import ciphers

books = []
book_pages = []
book_pages_content = []
for i in range(6):
    books.append("page"+str(i+1)+".txt")
    book_pages.append(open(books[i],"r"))
    book_pages_content.append(ciphers.words_list(list(ciphers.format_string(ciphers.remove_punc(book_pages[i].read()), True))))
book = open("book.txt","r")
book_content = book.read()

book_content = list(ciphers.format_string(ciphers.remove_punc(book_content),True))

_words_list = ciphers.words_list(book_content)

msg = ""
for i in range(6):
    print(len(book_pages_content[i]))
while (msg.upper() != "STOP"):
    
    msg = input("IDX: ")
    ints = [int(i) for i in list(msg) if i.isdigit()]
    integers = ""
    for i in ints:
        integers += str(i)
    if integers != None and int(integers) < len(_words_list):
        print(_words_list[int(integers)-1])


