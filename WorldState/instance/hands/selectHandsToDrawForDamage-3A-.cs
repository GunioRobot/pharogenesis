selectHandsToDrawForDamage: damageList
	"Select the set of hands that must be redrawn because either (a) the hand itself has changed or (b) the hand intersects some damage rectangle."

	| result hBnds |
	result := OrderedCollection new.
	hands do: [:h |
		h needsToBeDrawn ifTrue: [
			h hasChanged
				ifTrue: [result add: h]
				ifFalse: [
					hBnds := h fullBounds.
					(damageList detect: [:r | r intersects: hBnds] ifNone: [nil])
						ifNotNil: [result add: h]]]].
	^ result
