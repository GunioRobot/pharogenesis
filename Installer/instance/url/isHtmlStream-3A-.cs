isHtmlStream: page

	"matches  '<!DOCTYPE HTML', and <html>' "
	
	| first |	
	
	first := (page next: 14) asUppercase.
	
	^ (first = '<!DOCTYPE HTML') | (first beginsWith: '<HTML>')
	
