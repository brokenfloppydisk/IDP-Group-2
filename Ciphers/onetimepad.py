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

caesar = check_input("Are you using a caesar cipher? ")

key = None

if convert_key == True:
    key = ciphers.str_to_num(input("Key:"))
else:
    complete = False
    key = []
    while complete!=True:
        user_input = input("Next key value (Type end to stop): ").upper()
        if type(user_input) == int:
            key.append(user_input)
        elif "END" in input:
            complete=True
        else:
            print("Invalid input. Please try again.")


encode = check_input("Are you encoding a cipher? ")

secret_message = input("Input encoded cipher or cipher to decode: ")

output = ciphers.one_time_pad(secret_message, key, encode, caesar)

print("Output: " + str(output))




