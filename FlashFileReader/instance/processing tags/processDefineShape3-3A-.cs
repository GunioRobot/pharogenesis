processDefineShape3: data
	data hasAlpha: true.
	self processShapesFrom: data.
	data hasAlpha: false.
	^true