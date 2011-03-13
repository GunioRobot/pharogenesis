activate
	"Activate the owner too."

	|mo mc|
	mo := self modalOwner.
	mc := self modalChild.
	mc isNil
		ifFalse: [mc owner notNil ifTrue: [
				mc activate.
				^mc modalChild isNil ifTrue: [mc indicateModalChild]]].
	(self paneMorphs size > 1 and: [self splitters isEmpty])
		ifTrue: [self addPaneSplitters].
	super activate.
	self basicActivate.
	self rememberedKeyboardFocus
		ifNil: [(self respondsTo: #navigateFocusForward)
				ifTrue: [self navigateFocusForward]]
		ifNotNilDo: [:m | m world
						ifNil: [self rememberKeyboardFocus: nil] "deleted"
						ifNotNilDo: [:w | 
							m wantsKeyboardFocus
								ifTrue: [m takeKeyboardFocus]
								ifFalse: [(self respondsTo: #navigateFocusForward)
											ifTrue: [self navigateFocusForward]]]].
	(mo notNil and: [mo isKindOf: SystemWindow])
		ifTrue: [mo bringBehind: self]