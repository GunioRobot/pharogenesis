trailer
	"append the HTML trailer.  Call this just before file close.
	4/4/96 tk"
	| cr |
	cr _ String with: Character cr.
	self command: '/BODY'; verbatim: cr.
	self command: '/HTML'; verbatim: cr.
