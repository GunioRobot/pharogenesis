clipFlagsX: x y: y z: z w: w
	"Determine the clip flags for the given vector.
	The clip flags are a combination of inside and outside flags that can be used to easily reject an entire buffer if it is completely inside or outside and can also be used to detect the most commen cases in clipping (e.g., intersection with one boundary only)."
	| w2 flags |
	w2 _ w negated.
	flags _ 0.
	flags _ flags bitOr:(x >= w2 ifTrue:[InLeftBit] ifFalse:[OutLeftBit]).
	flags _ flags bitOr:(x <= w ifTrue:[InRightBit] ifFalse:[OutRightBit]).
	flags _ flags bitOr:(y >= w2 ifTrue:[InBottomBit] ifFalse:[OutBottomBit]).
	flags _ flags bitOr:(y <= w ifTrue:[InTopBit] ifFalse:[OutTopBit]).
	flags _ flags bitOr:(z >= w2 ifTrue:[InFrontBit] ifFalse:[OutFrontBit]).
	flags _ flags bitOr:(z <= w ifTrue:[InBackBit] ifFalse:[OutBackBit]).
	^flags