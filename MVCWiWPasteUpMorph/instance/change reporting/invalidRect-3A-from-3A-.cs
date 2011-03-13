invalidRect: damageRect from: aMorph

	worldState ifNil: [^self].
	worldState recordDamagedRect: damageRect
