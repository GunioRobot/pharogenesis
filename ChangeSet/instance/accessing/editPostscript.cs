editPostscript
	"edit the receiver's postscript, in a separate window.  "

	| deps found |
	self assurePostscriptExists.
	deps := postscript dependents 
				select: [:m | (m isSystemWindow) or: [m isKindOf: StandardSystemView]].
	deps size > 0 
		ifTrue: 
			[Smalltalk isMorphic 
				ifTrue: 
					[found := deps 
								detect: [:obj | obj isSystemWindow and: [obj world == self currentWorld]]
								ifNone: [nil].
					found ifNotNil: [^found activate]]
				ifFalse: 
					[found := deps detect: 
									[:obj | 
									(obj isKindOf: StandardSystemView) 
										and: [ScheduledControllers scheduledControllers includes: obj controller]]
								ifNone: [nil].
					found 
						ifNotNil: [^ScheduledControllers activateController: found controller]].
			self 
				inform: 'Caution -- there' , (deps size isOrAreStringWith: 'other window') 
						, '
already open on this postscript elsewhere'].
	postscript openLabel: 'Postscript for ChangeSet named ' , name