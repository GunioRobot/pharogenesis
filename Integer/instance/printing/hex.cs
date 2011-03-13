hex
"receiver is in range 0 to 255. Returns a two 'digit' hexadecimal representation of the receiver.
If you want no padding use asHexDigit or printStringHex. i.e.
     15 printStringHex ==  'F'
     15 asHexDigit == $F
     15 hex == '0F'"
^self printStringBase: 16 length: 2 padded: true
