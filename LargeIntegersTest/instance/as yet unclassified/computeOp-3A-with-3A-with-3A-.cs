computeOp: anOpSymbol with: arg1 with: arg2 
	| res |
	stream cr; print: anOpSymbol; cr.
	stream nextPutAll: 'arg1: ';
	 print: arg1;
	 cr;
	 nextPutAll: 'arg2: ';
	 print: arg2.
	res _ arg1 perform: anOpSymbol with: arg2.
	stream cr; nextPutAll: 'res: '; print: res