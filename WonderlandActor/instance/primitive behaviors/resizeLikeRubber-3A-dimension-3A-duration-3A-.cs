resizeLikeRubber: amount dimension: aDimension duration: aDuration
	"Resizes the object using a volume preserving resize"

	| x y z |

	(aDuration = rightNow) ifTrue: [
		(aDimension = leftToRight)
			ifTrue: [
						x _ amount.
						y _ 1 / (amount sqrt).
						z _ 1 / (amount sqrt).
					]
			ifFalse: [ (aDimension = topToBottom)
					ifTrue: [
								x _ 1 / (amount sqrt).
								y _ amount.
								z _ 1 / (amount sqrt).
							]
					ifFalse: [ (aDimension = frontToBack)
							ifTrue: [
										x _ 1 / (amount sqrt).
										y _ 1 / (amount sqrt).
										z _ amount.
									].
							].
					].

			^ self resize: { x. y. z } duration: aDuration.
		].

	^ self resizeLikeRubber: amount dimension: aDimension duration: aDuration style: gently.
