global: globalNameSymbol selector: selectorSymbol args: argArray
    "Initialize self as a DiskProxyQ constructor with the given
     globalNameSymbol, selectorSymbol, and argument Array, and an
     empty message queue.
     I will internalize by looking up the global object name in the
     SystemDictionary (Smalltalk), sending it this message with
     these arguments, and then sending it all queued up messages.
     In the interim, I can enqueue messages. -- 11/9/92 jhm"

    messageQueue _ nil.
    ^ super global: globalNameSymbol selector: selectorSymbol args: argArray