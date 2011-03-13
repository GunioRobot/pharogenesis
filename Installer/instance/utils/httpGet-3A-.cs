httpGet: aUrl

	| page |

	page := self classHTTPSocket httpGet: aUrl accept: 'application/octet-stream'.  
 
	(page respondsTo: #reset)  ifFalse: [ self error: 'unable to contact web site' ].
 
	^ page
	