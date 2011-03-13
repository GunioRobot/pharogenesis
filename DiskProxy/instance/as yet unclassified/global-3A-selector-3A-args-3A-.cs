global: globalNameSymbol selector: selectorSymbol args: argArray
    "Initialize self as a DiskProxy constructor with the given
     globalNameSymbol, selectorSymbol, and argument Array.
     I will internalize by looking up the global object name in the
     SystemDictionary (Smalltalk) and sending it this message with
     these arguments."

    Symbol mustBeSymbol: (globalObjectName _ globalNameSymbol).
    Symbol mustBeSymbol: (constructorSelector _ selectorSymbol).
    constructorArgs _ argArray