import ciphers

book = open("book.txt","r")
book_content = book.read()

secret_message = input("Secret Message: ")

key = ciphers.book_cipher(book_content,secret_message)

print("The key for the book cipher is:")
print(key)

print("Decoding the book cipher gives:")
print(ciphers.decode_book(book_content, key))