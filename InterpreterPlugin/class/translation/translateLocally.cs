translateLocally
	^self translate: (self moduleName,'.c') doInlining: true locally: true