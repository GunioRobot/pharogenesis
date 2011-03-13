urlGet: aUrl

	| page |

	page := HTTPSocket httpGet: aUrl accept: 'application/octet-stream'.  
 
	(page respondsTo: #reset)  ifFalse: [ ^ nil ].
 
	(self isHtmlStream: page) ifTrue: [ page := self extractFromHtml: page option: nil ].

	^ page reset
	