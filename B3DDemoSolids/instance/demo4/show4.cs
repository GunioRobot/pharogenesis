show4

    " B3DDemoSolids new show4"

     | view |

  self createScene4.
  (view := B3DTutorialScenePresenterMorph new)
     source: self description: #descriptionScene4;
     scene: scene.
 
  view rotateX: 25.4.
  view openInSystemWindow.