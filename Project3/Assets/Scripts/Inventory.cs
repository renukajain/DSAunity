using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory : MonoBehaviour
{

    public static Inventory instance = null;
    public string ID;
    public int turtleQuantity;
    public int coffQuantity;
    public int redBullQuantity;
    public int pillsQuantity;
    public int calculatorQuantity;
    public int ruleQuantity;
    public int compassQuantity;
    public int pencilQuantity;
    public int glassesQuantity;
    public int puzzleQuantity;
    public int bookQuantity;
    public int usbQuantity;
    public int cheatQuantity;
    public int coinsQuantity;

    public int calcAch;
    public int electronicsAch;
    public int commsAch;
    public int oescAch;
    public int dsaAch;
    public int aeroAch;
    public int tfgAch;

    public void SetCalc(){
        this.calcAch=1;
    }
    public void SetElec(){
        this.electronicsAch=1;
    }
    public void SetComms(){
        this.commsAch=1;
    }
    public void SetOesc(){
        this.oescAch=1;
    }
    public void SetAero(){
        this.aeroAch=1;
    }
    public void SetTfg(){
        this.tfgAch=1;
    }
    public int GetCalc(){
        return this.calcAch;
    }
    public int GetElec(){
        return this.electronicsAch;
    }
    public int GetComms(){
        return this.commsAch;
    }
    public int GetOesc(){
        return this.oescAch;
    }
    public int GetDsa(){
        return this.dsaAch;
    }
    public int GetAero(){
        return this.aeroAch;
    }
    public int GetTfg(){
        return this.tfgAch;
    }




    public void SetID(string text){
        this.ID=text;
    }
    public void SetTurtle(int q){
        this.turtleQuantity=q;
    }
    public void SetCoffee(int q){
        this.coffQuantity=q;
    }
    public void SetRedBull(int q){
        this.redBullQuantity+=q;
    }
    public void SetPills(int q){
        this.pillsQuantity+=q;
    }
    public void SetCalculator(int q){
        this.calculatorQuantity+=q;
    }
    public void SetRule(int q){
        this.ruleQuantity+=q;
    }
    public void SetCompass(int q){
        this.compassQuantity+=q;
    }
    public void SetPencil(int q){
        this.pencilQuantity+=q;
    }
    public void SetGlasses(int q){
        this.glassesQuantity+=q;
    }
    public void SetUsb(int q){
        this.usbQuantity+=q;
    }
    public void SetBook(int q){
        this.bookQuantity+=q;
    }
    public void SetPuzzle(int q){
        this.puzzleQuantity+=q;
    }
    public void SetCheat(int q){
        this.cheatQuantity+=q;
    }
    public void SetCoins(int q){
        this.coinsQuantity+=q;
    }

    public string GetID(){
        return this.ID;
    }
    public int GetTurtle(){
        return this.turtleQuantity;
    }
    public int GetCoffee(){
        return this.coffQuantity;
    }
    public int GetRedBull(){
        return this.redBullQuantity;
    }
    public int GetPills(){
        return this.pillsQuantity;
    }
    public int GetCalculator(){
        return this.calculatorQuantity;
    }
    public int GetRule(){
        return this.ruleQuantity;
    }
    public int GetCompass(){
        return this.compassQuantity;
    }
    public int GetPencil(){
        return this.pencilQuantity;
    }
    public int GetUsb(){
        return this.usbQuantity;
    }
    public int GetGlasses(){
        return this.glassesQuantity;
    }
    public int GetBook(){
        return this.bookQuantity;
    }
    public int GetPuzzle(){
        return this.puzzleQuantity;
    }
    public int GetCheat(){
        return this.cheatQuantity;
    }
    public int GetCoins(){
        return this.coinsQuantity;
    }

}