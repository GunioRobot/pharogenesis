printOnStream: aStream
	aStream 
		print: self class name;
		print:'(';
		write: start;
		print:' - ';
		write: end;
		print:')'.