advance
    | this |
    prevMark _ hereMark.
    prevToken _ "Now means prev size"
        self previousTokenSize.
    this _ here.
    here _ token.
    hereType _ tokenType.
    hereMark _ mark.
    self scanToken.
    ^this