grabNewGraphicIn: aMorph event: evt
	"Used by any morph that can be represented by a graphic"
	self form: Form fromUser.
	self direction: self form width @ 0.
	self normal: 0 @ self form height.
	aMorph changed.