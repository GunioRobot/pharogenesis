findHandlerFrom: startCtx

       | ctx handler |
       ctx := startCtx.
       [ctx == nil]
               whileFalse:
                       [ctx isHandlerContext
                               ifTrue:
                                       [handler := ctx tempAt: 1. "the first argument"
                                       ((handler handles: self) and: [(ctx tempAt: 2) sender == nil])
                                               ifTrue: [^ctx]].
                       ctx := ctx sender].
       ^nil