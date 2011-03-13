comeFullyUpOnReload
    "Internalize myself into a fully alive object after raw loading
     from a DataStream/ReferenceStream.
     For DiskProxyQ: Invoke the constructor message and send my queue of messages to
     the result. (See my class comment.)
     The sender (the ReferenceStream facility) will substitute the answer
     for myself, even if that means asking me to ‘become: myAnswer’. -- 11/9/92 jhm
     12/1/92 jhm: Remove the 1-element-array optimization."
    | answer |

    answer _ super comeFullyUpOnReload.

    messageQueue == nil ifFalse:
        [messageQueue do: [:msg | msg sendTo: answer]].

    ^ answer