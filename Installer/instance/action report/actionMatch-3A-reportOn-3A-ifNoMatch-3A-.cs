actionMatch: theLine reportOn: report ifNoMatch: aBlock

	| line |
	
	line := theLine withBlanksCondensed.
	
	((line beginsWith: 'Installer install:') | (line beginsWith: 'Installer do:')) 
		ifTrue: [ ^self webAction: theLine reportOn: report ].
	
	
	((line beginsWith: 'Installer installUrl:') and: 
		[ | ext |
		 ext :=  (line readStream upToAll: '''.') copyAfterLast: $..
		 (#( 'cs' 'st' 'mcz' 'sar') includes: ext) not ]) ifTrue: [ ^self urlAction: theLine reportOn: report ].

	(line beginsWith: 'Installer mantis fixBug:') ifTrue: [ ^self mantisAction: theLine reportOn: report ].
	
	
	aBlock value.
