startPage
	"return the contents of the user's personal start page"
	| file |
	file _ FileStream oldFileOrNoneNamed: 'StartPage.html'.
	file 
		ifNil: [ ^'<title>Personal Start Page</title>\<h1>Personal Start Page</h1>\This space is empty' withCRs ]
		ifNotNil: [ ^file contentsOfEntireFile ]