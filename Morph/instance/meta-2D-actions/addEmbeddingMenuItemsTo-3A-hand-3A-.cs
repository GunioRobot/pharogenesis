addEmbeddingMenuItemsTo: aMenu hand: aHandMorph
	"Construct a menu offerring embed targets for the receiver.  If the incoming menu is is not degenerate, add the constructed menu as a submenu; in any case, answer the embed-target menu"

	| menu |
	menu _ MenuMorph new defaultTarget: self.
	self potentialEmbeddingTargets reverseDo: [:m | 
		menu add: (m knownName ifNil:[m class name asString]) target: m selector: #addMorphFrontFromWorldPosition: argumentList: {self topRendererOrSelf}].
	aMenu ifNotNil:
		[menu submorphCount > 0 
			ifTrue:[aMenu add:'embed into' translated subMenu: menu]].
	^ menu