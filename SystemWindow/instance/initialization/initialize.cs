initialize
	"Initialize a system window. Add label, stripes, etc., if desired"
	super initialize.
	allowReframeHandles := true.
	labelString
		ifNil: [labelString := 'Untitled Window' translated].
	isCollapsed := false.
	activeOnlyOnTop := true.
	paneMorphs := Array new.
	Preferences alternativeWindowLook
		ifTrue: [""
			borderColor := #raised.
			borderWidth := 2.
			color := Color white]
		ifFalse: [""
			borderColor := Color black.
			borderWidth := 1.
			color := Color black].
	self layoutPolicy: ProportionalLayout new.
	self wantsLabel
		ifTrue: [self initializeLabelArea].
	self
		on: #mouseEnter
		send: #spawnReframeHandle:
		to: self.
	self
		on: #mouseLeave
		send: #spawnReframeHandle:
		to: self.
	self extent: 300 @ 200.
	mustNotClose := false.
	updatablePanes := Array new