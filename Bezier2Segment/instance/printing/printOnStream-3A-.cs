printOnStream: aStream
	aStream 
		print: self class name;
		print:'from: ';
		write: start;
		print:'via: ';
		write: via;
		print:'to: ';
		write: end;
		print:' '.