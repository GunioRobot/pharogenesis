remove: msgID 
	"Remove the entry with the given ID from my Dictionary."
	self privateRemove: msgID.
	self logStream nextPutAll: 'remove';
	 cr;
	 print: msgID;
	 cr;
	 close