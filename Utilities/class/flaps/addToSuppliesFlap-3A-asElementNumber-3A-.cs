addToSuppliesFlap: aMorph asElementNumber: aNumber
	self addMorph: aMorph asElementNumber: aNumber inGlobalFlapSatisfying:
		[:aFlap | aFlap wording = 'Supplies']
	