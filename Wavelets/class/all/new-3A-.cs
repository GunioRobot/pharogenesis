new: n
	^ self basicNew setFilters: ((1 to: n) collect: [:i | Array new: 2*i]).