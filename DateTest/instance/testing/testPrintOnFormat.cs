testPrintOnFormat
	| cs rw |
	cs := ReadStream on: '04*Jan*23'.
	rw := ReadWriteStream on: ''.
	aDate printOn: rw format: #(3 2 1 $* 2 2).
	self assert: rw contents = cs contents