startPage: title
	| stream |
	stream _ WriteStream on: ''.
	stream nextPutAll: '<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 3.2//EN">'; cr;
	 nextPutAll: '<HTML>';cr;
	 nextPutAll: '<HEAD>';cr;
	 nextPutAll: '<TITLE>'; nextPutAll: title; nextPutAll: '</TITLE>';cr;
	 nextPutAll: '<BODY>'; cr. 
	^ stream contents