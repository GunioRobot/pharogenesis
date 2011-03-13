copyWithTally: hitCount
	^ (MessageTally new class: class method: method) bump: hitCount