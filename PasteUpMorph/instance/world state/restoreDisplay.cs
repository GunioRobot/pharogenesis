restoreDisplay

	self == World ifTrue:  "Else we're a morphic world-window in an mvc worldState and the restoreDisplay was, unusually, issued from the world's menu rather than from the mvc screen menu"
		[DisplayScreen startUp.
		self extent: Display extent.
		self viewBox: Display boundingBox.
		self handsDo: [:h | h endDisplaySuppression].
		self restoreFlapsDisplay].
	self fullRepaintNeeded