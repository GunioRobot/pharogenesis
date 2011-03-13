convertClassAddsToClassChanges
	"1/22/96 sw: as part of a general policy of not storing 'new class' ever, but always having it as a changed class, in order to preserve the specific messages that get changed within this change set, we need to morph existing changesets so that class-adds become class-changes.  This has no method senders, but rather is for invocation from a doit.
	Note that this adds all the selectors for each added class to the changed method list"

	| chg aClass |
	self flag: #scottPrivate.
	self changedClassNames do:
		[:aClassName |
			chg _ self classChangeAt: aClassName.
			(chg includes: #add) ifTrue:
				[chg remove: #add.
				chg add: #change.
				aClass _ Smalltalk at: aClassName.
				aClass selectorsDo:
					[:aSelector | self addSelector: aSelector class: aClass].
				aClass class selectorsDo:
					[:aSelector | self addSelector: aSelector class: aClass class]]]