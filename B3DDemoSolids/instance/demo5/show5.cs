show5

    " B3DDemoSolids new show5"

     | view |

  self createScene5.
  (view := B3DTutorialScenePresenterMorph new)
     source: self description: #descriptionScene5;
     scene: scene.
 
  view rotateX: 25.4.
  view openInSystemWindow.