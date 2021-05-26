import ciphers

book = open("book.txt","r")
book_content = book.read()

missing_letters = []
for i in ciphers.alphabet():
    if i not in book_content and i.lower() not in book_content:
        missing_letters.append(i)

if missing_letters is not None:
    print("Missing letters: " + str(missing_letters))

secret_message = input("Secret Message: ")

key = ciphers.book_cipher(book_content,secret_message)

print("The key for the book cipher is:")
print(key)

if key is not None:
    print("Decoding the book cipher gives:")
    print(ciphers.decode_book(book_content, key))