confirm: queryString 
	"Put up a yes/no menu with caption aString. Answer true if the response is yes, false if no. This is a modal question--the user must respond yes or no."
	"nil confirm: 'Are you hungry?'"

	^ SelectionMenu confirm: queryString