wearCostumeOf: anotherPlayer
	"Put on a costume similar to the one currently worn by anotherPlayer"
	| itsCostume |

	itsCostume _ anotherPlayer costume renderedMorph.
	(itsCostume isKindOf: SketchMorph)
		ifTrue:
			[self wearSketchCostumeResembling: itsCostume]
		ifFalse:
			[anotherPlayer costume player: nil.
			self renderedCostume: itsCostume veryDeepCopy.
			anotherPlayer costume player: anotherPlayer].
	costume layoutChanged