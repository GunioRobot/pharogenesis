parseArgsAndTemps: aString notifying: req 
        "Parse the argument, aString, notifying req if an error occurs. Otherwise, 
        answer a two-element Array containing Arrays of strings (the argument 
        names and temporary variable names)."

        (req notNil and: [RequestAlternateSyntaxSetting signal]) ifTrue:
                [^ (self as: DialectParser) parseArgsAndTemps: aString notifying: req].
        aString == nil ifTrue: [^#()].
        doitFlag _ false.               "Don't really know if a doit or not!"
        ^self initPattern: aString
                notifying: req
                return: [:pattern | (pattern at: 2) , 	self temporariesIn: (pattern at: 1)]