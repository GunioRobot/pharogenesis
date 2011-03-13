maFiles
 
 | file files bugPage id  | 
 
 files := Dictionary new.
 
 bugPage := self maPage.

 [
  id := bugPage upToAll: 'href="file_download.php?file_id='; upTo: $&. 
 file := bugPage upToAll: 'amp;type=bug"' ; upTo: $<.
 
 ((file size > 1) and: [file first = $>]) ifTrue: [ files at: file copyWithoutFirst put: id ].
 
 id notEmpty ] whileTrue.

^files 