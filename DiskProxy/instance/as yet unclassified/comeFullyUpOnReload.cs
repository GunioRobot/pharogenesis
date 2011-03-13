comeFullyUpOnReload
    "Internalize myself into a fully alive object after raw loading
     from a DataStream. (See my class comment.)
     The sender (the DataStream facility) will substitute the answer
     for myself, even if that means doing ‘me become: myAnswer’."
    | globalObj |

    globalObj _ Smalltalk at: globalObjectName
        ifAbsent: [^ self halt: 'can’t internalize'].
    Symbol mustBeSymbol: constructorSelector.    

    ^ globalObj perform: constructorSelector
          withArguments: constructorArgs