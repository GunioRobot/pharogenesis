benchmark "Time millisecondsToRun: [10 benchmark]
	11950 (AST 1.0 3/31 on 8100 (arith & spl prims in primary dispatch)
	15100 (AST 1.0 3/20 on 8100 (checkProcessSwitch out of inner loop)
	17033 (AST 1.0 3/15 on 8100)
	35483 (AST 1.0 3/1 on 8100)
	4110 (PPS interpreter on 8100)
	10880 (APDA interpreter on Duo)"
    | size flags i prime k count iter |
    size _ 8190.
    1 to: self do:
        [:iter |
        count _ 0.
        flags _ (Array new: size) atAllPut: true.
        1 to: size do:
            [:i | (flags at: i) ifTrue:
                [prime _ i+1.
                k _ i + prime.
                [k <= size] whileTrue:
                    [flags at: k put: false.
                    k _ k + prime].
                count _ count + 1]]].
    ^ count