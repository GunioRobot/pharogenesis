mergeFn: arg1 with: arg2
	^ self perform: (self cCoerce:(opTable at: combinationRule+1) to:'(int (*) (int,int))')
		with: arg1 with: arg2