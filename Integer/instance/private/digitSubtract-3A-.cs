digitSubtract: arg
	| smaller larger z sum sl al ng |
	sl _ self digitLength.
	al _ arg digitLength.
	(sl = al
		ifTrue: 
			[[(self digitAt: sl) = (arg digitAt: sl) and: [sl > 1]]
				whileTrue: [sl _ sl - 1].
			al _ sl.
			(self digitAt: sl) < (arg digitAt: sl)]
		ifFalse: [sl < al])
		ifTrue: 
			[larger _ arg.
			smaller _ self.
			ng _ self negative == false.
			sl _ al]
		ifFalse: 
			[larger _ self.
			smaller _ arg.
			ng _ self negative].
	sum _ Integer new: sl neg: ng.
	z _ 0.
	"Loop invariant is -1<=z<=1"
	1 to: sl do:
		[:i |
		z _ z + (larger digitAt: i) - (smaller digitAt: i).
		sum digitAt: i
			put: z - (z // 256 * 256) "sign-tolerant form of (z bitAnd: 255)".
		z _ z // 256].
	^ sum normalize