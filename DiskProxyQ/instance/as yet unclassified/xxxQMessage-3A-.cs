xxxQMessage: aMessage
    "Enqueue aMessage on the queue of messages that I will send the newly-created
     object at internalization time.
     IMPLEMENTATION: My instance variable messageQueue holds either nil or an Array
        of objects to sendTo: the object I'm internalizing to (generally of class
        Message or Symbol). -- 11/9/92 jhm
     12/1/92 jhm: Remove the 1-element-array optimization."

    messageQueue _ messageQueue == nil
        ifTrue:  [Array with: aMessage]
        ifFalse: [messageQueue,, aMessage]