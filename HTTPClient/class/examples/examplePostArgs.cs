examplePostArgs
	"HTTPClient examplePostArgs"

	| args result resultStream |
	args _ Dictionary new.
	args
		at: 'arg1' put: #('val1');
		at: 'arg2' put: #('val2');
		yourself.
	resultStream _ HTTPClient httpPostDocument: 'http://www.squeaklet.com/cgi-bin/thrd.pl'  args: args.
	result _ resultStream upToEnd.
	Transcript show: result; cr; cr.
	resultStream close

