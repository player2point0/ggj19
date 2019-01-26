import * as p5 from '@code-dot-org/p5'
import '@code-dot-org/p5.play/lib/p5.play.js'

var scene = function(p) {
    var keys = [];
    
    var processInput;
    
    const Player = function(x, y) {
      this.x = x;
      this.y = y;
      this.symbol = undefined
      this.sticks = 0;
      
      this.draw = function() {
        p.fill(0, 0, 0);
        this.x = p.constrain(this.x, 0, p.width - 40);
        this.y = p.constrain(this.y, 0, p.height-100);
        this.symbol = p.createSprite(this.x, this.y, 40, 40);
      };
      
      this.moveUp = function() {
        this.y -= 5;
      };
      
      this.moveDown = function() {
        this.y += 5;
      };
      
      this.moveRight = function() {
        this.x += 5;
      };
      
      this.moveLeft = function() {
        this.x -= 5;
      };
      
    };
    
    processInput = function() {
      if(keys[37]) player.moveLeft();
      if(keys[38]) player.moveUp()
      if(keys[39]) player.moveRight();
      if(keys[40]) player.moveDown();
    };
    
    var player = new Player(30,300);
    
    p.preload = function() {}
    
    p.setup = function() {
      p.frameRate(30);
      p.createCanvas(400,400);
    };
    
    p.draw = function(){        
      p.background(227, 254, 255);
         
      processInput();   
          
      player.draw();
    };
    
    p.keyPressed = function(){
      keys[p.keyCode] = true;
    };
    
    p.keyReleased = function(){
      keys[p.keyCode] = false;
    };
  };
  
var P5 
P5 = P5 || new p5(scene)

if (module.hot) {
  module.hot.accept()
}