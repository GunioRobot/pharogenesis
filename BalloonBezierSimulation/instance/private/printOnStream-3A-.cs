printOnStream: aStream
	aStream 
		print: self class name;
		print:'(';
		write: start;
		print:' - ';
		write: via;
		print:' - ';
		write: end;
		print:')'.