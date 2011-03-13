doesNotUnderstand: aMessage
    "Enqueue a message for the object that I will internalize to. Return self, which
     is the best I can do (sorry!), noting that self will #become: the object I
     internalize to. See my class comment for more info and warnings. -- 11/9/92 jhm"

    self xxxQMessage: aMessage.
    ^ self