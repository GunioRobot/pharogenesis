paneColor
	| cc |
	(cc := self valueOfProperty: #paneColor) ifNotNil: [
		^Preferences fadedBackgroundWindows
			ifTrue: [self isActive
					ifTrue: [cc]
					ifFalse: [cc alphaMixed: 0.5 with: (Color white alpha: cc alpha)]]
			ifFalse: [cc]].
	cc := paneMorphs isEmptyOrNil ifFalse: [paneMorphs first color].
	cc ifNil: [cc := self defaultBackgroundColor].
	cc isTransparent ifTrue: [cc := self defaultBackgroundColor].
	self setProperty: #paneColor toValue: cc.
	^self paneColor