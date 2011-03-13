updateReferencesUsing: refDict
	| anchors range new |
	super updateReferencesUsing: refDict.
	"Update any anchors in the text of a newly copied morph"
	anchors _ IdentityDictionary new.
	text runs withStartStopAndValueDo:
		[:start :stop :attributes |
		attributes do: [:att | (att isMemberOf: TextAnchor)
							ifTrue: [anchors at: att put: (start to: stop)]]].
	anchors isEmpty ifTrue: [^ self].
	anchors keysDo:
		[:old |  range _ anchors at: old.
		text removeAttribute: old from: range first to: range last.
		new _ TextAnchor new anchoredMorph:
					(refDict at: old anchoredMorph).
		text addAttribute: new from: range first to: range last].
	self layoutChanged "for good measure"