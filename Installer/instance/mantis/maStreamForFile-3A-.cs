maStreamForFile: aFileName

	| fileId  |

 	fileId :=  self maFiles at: aFileName ifAbsent: [ self error: aFileName, ' not found' ].

 	^ self httpGet: (self ma, 'file_download.php?file_id=' , fileId , '&type=bug').
	 