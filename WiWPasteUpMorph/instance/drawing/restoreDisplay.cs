restoreDisplay

	"RAA 27 Nov 99 - we do not change our size just because the Display changed"

	self == World ifTrue:  "Else we're a morphic world-window in an mvc worldState and the restoreDisplay was, unusually, issued from the world's menu rather than from the mvc screen menu"
		[DisplayScreen startUp.
		self handsDo: [:h | h endDisplaySuppression].
		self restoreFlapsDisplay].
	self fullRepaintNeeded